<script lang="ts">
    import {beforeUpdate} from "svelte";
    import Card from "../lib/Card.svelte";

    //Tools
    import Condition from "../lib/tools/Condition";

    //Services
    import Service from "../lib/services/Service";
    import RoutingService from "../lib/services/RoutingService.js";

    let values = Service.GetChuckNorrisCategories();

    function capitalizeFirstLetter(str) {
        return str.replace(/^./, str[0].toUpperCase());
    }

    let query = '';
    let timeout;

    beforeUpdate(() => {
        if (timeout)
            clearTimeout(timeout);

        if (Condition.isStringNotEmpty(query)) {
            timeout = setTimeout(() => {
                RoutingService.goto(`/space/norris/search?query=${query}`);
            }, 500);
        }
    });
</script>

<style>

</style>

<div on:click={() => RoutingService.goto(`/start/wars/people`)}>
    <Card>
        Start Wars People that Chuck Norris know
    </Card>
</div>

<div>
    Search
    <input type="search" bind:value={query} />
</div>

{#await values}
    <p>Loading...</p>
{:then value}
    <h3>Chuck Norris Categories</h3>
    {#each value as data, index}
        <div on:click={() => RoutingService.goto(`/jokes/random?category=${data}`)}>
            <Card>
                {index + 1}. {capitalizeFirstLetter(data)}
            </Card>
        </div>
    {/each}
{/await}