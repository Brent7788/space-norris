<script lang="ts">
    import {onMount} from "svelte";
    import Jokes from "./Jokes.svelte";
    import Card from "../../lib/Card.svelte";

    //Tools
    import Condition from "../../lib/tools/Condition.js";

    //Services
    import RoutingService from "../../lib/services/RoutingService";
    import Service from "../../lib/services/Service";
    import People from "./People.svelte";

    let data: Promise<any>;
    let query = "";
    let showNorris = true;

    onMount(async () => {
        const routingService = new RoutingService();

        query = routingService.paramObject.query as string;
        data = Service.Search(query);
    });

    function search() {
        data = Service.GetChuckNorrisJokesByCategory(query);
    }
</script>

{#await data}
    <p>Loading...</p>
{:then value}
    <!--{JSON.stringify(value)}-->
    {#if Condition.hasSomeValue(value)}
        <div style="display: inline;" on:click={() => showNorris = true}>
            <Card style="display: inline; border-style: solid;  border-width: 1px; border-bottom-width: 2px; border-bottom-color: red;">
                Chuck Norris Jokes
            </Card>
        </div>
        <div style="display: inline;" on:click={() => showNorris = false}>
            <Card style="display: inline; border-style: solid;  border-width: 1px; border-bottom-width: 2px;">
                Start Wars People
            </Card>
        </div>
        {#if showNorris}
            <div style="margin-top: 20px;">
                <Jokes jokes={JSON.parse(value.chuckNorrisJokes).result}></Jokes>
            </div>
        {:else}
            <div style="margin-top: 20px;">
                <People people={JSON.parse(value.startWarsPeople).results}></People>
            </div>
        {/if}
    {/if}
{/await}