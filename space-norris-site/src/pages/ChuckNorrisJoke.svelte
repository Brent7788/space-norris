<script lang="ts">
    import {onMount} from "svelte";
    import Card from "../lib/Card.svelte";

    //Tools
    import Condition from "../lib/tools/Condition.js";

    //Services
    import RoutingService from "../lib/services/RoutingService";
    import Service from "../lib/services/Service";
    import NorrisJokeDetails from "../lib/NorrisJokeDetails.svelte";

    let data: Promise<any>;
    let category = "";

    onMount(async () => {
        const routingService = new RoutingService();

        category = routingService.paramObject.category as string;
        data = Service.GetChuckNorrisJokesByCategory(category);
    });

    function getNewRandomJoke() {
        data = Service.GetChuckNorrisJokesByCategory(category);
    }
</script>

{#await data}
    <p>Loading...</p>
{:then joke}
    {#if Condition.hasSomeValue(joke)}
        <div on:click={() => RoutingService.goto("/home")}>
            <Card>
                - Back to categories
            </Card>
        </div>
        <div on:click={getNewRandomJoke}>
            <Card>
                - New Joke
            </Card>
        </div>
        <NorrisJokeDetails {joke}></NorrisJokeDetails>
    {/if}
{/await}