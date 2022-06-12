<script lang="ts">
    import {beforeUpdate, onMount} from "svelte";
    import Jokes from "./Jokes.svelte";
    import Card from "../../lib/Card.svelte";
    import Input from "../../lib/Input.svelte";

    //Tools
    import Condition from "../../lib/tools/Condition.js";

    //Services
    import RoutingService from "../../lib/services/RoutingService";
    import Service from "../../lib/services/Service";
    import People from "./People.svelte";

    let data: Promise<any>;
    let query = "";
    let oldQuery = ""
    let timeout;
    let showNorris = true;

    onMount(async () => {
        const routingService = new RoutingService();

        query = routingService.paramObject.query as string;
        data = Service.Search(query);
    });

    function search() {
        data = Service.Search(query);
    }

    beforeUpdate(() => {
        if (timeout)
            clearTimeout(timeout);

        if (Condition.isStringNotEmpty(query) && query !== oldQuery) {
            oldQuery = query;
            timeout = setTimeout(() => {
                search();
            }, 500);
        }
    });
</script>

<div on:click={() => RoutingService.goto("/home")}>
    <Card>
        - Back to home
    </Card>
</div>
<div>
    <Input label="Search"
           placeholder="Search for jokes or Start Wars People"
           type="search"
           style="margin-top: 5px; margin-bottom: 35px"
           bind:value={query}>
    </Input>
</div>

{#await data}
    <p>Loading...</p>
{:then value}
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
                <Jokes jokes={JSON.parse(value.chuckNorrisJokes.chuckNorrisJokes).result}></Jokes>
            </div>
        {:else}
            <div style="margin-top: 20px;">
                <People people={JSON.parse(value.startWarsPeople.startWarsPeople).results}></People>
            </div>
        {/if}
    {/if}
{/await}