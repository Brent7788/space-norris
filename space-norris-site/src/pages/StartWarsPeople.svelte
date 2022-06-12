<script lang="ts">
    import Card from "../lib/Card.svelte";
    import {fly} from "svelte/transition";

    //Tools
    import Condition from "../lib/tools/Condition.js";

    //Services
    import RoutingService from "../lib/services/RoutingService";
    import Service from "../lib/services/Service";
    import StarWarsDetails from "../lib/StarWarsDetails.svelte";

    let data = Service.GetStartWarsPeople();
</script>

{#await data}
    <p>Loading...</p>
{:then value}
    {#if Condition.hasSomeValue(value)}
        <div on:click={() => RoutingService.goto("/home")}>
            <Card>
                - Back to Chuck Norris Jokes
            </Card>
        </div>

        {#each value.results as people, index}
            <div in:fly={{ x: 400, duration: 400, delay: 40 * index }}>
                <StarWarsDetails {people}></StarWarsDetails>
            </div>
        {/each}
    {/if}
{/await}