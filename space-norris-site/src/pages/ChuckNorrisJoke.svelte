<script lang="ts">
    import {onMount} from "svelte";
    import Card from "../lib/Card.svelte";

    //Tools
    import Condition from "../lib/tools/Condition.js";

    //Services
    import RoutingService from "../lib/services/RoutingService";
    import Service from "../lib/services/Service";

    let data: Promise<any>;
    let category = "";

    onMount(async () => {
        const routingService = new RoutingService();

        category = routingService.paramObject.category as string;
        data = Service.GetChuckNorrisJokesByCategory(category);
    });

    function joke() {
        data = Service.GetChuckNorrisJokesByCategory(category);
    }
</script>

{#await data}
    <p>Loading...</p>
{:then value}
    <!--{JSON.stringify(value)}-->
    {#if Condition.hasSomeValue(value)}
        <div on:click={() => RoutingService.goto("/home")}>
            <Card>
                - Back to categories
            </Card>
        </div>
        <div on:click={joke}>
            <Card>
                - New Joke
            </Card>
        </div>
        <Card>
            <label>Category:</label>
            <strong>{value.categories[0]}</strong>
            <br>
            <label>Created At:</label>
            {value.created_at.split(" ")[0]} <!--TODO Find better way-->
            <br>
            <label>Joke:</label>
            <strong>{value.value}</strong>
        </Card>
    {/if}
{/await}