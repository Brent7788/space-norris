<script lang="ts">
    import Card from "../lib/Card.svelte";

    //Tools
    import Condition from "../lib/tools/Condition.js";

    //Services
    import RoutingService from "../lib/services/RoutingService";
    import Service from "../lib/services/Service";

    let data = Service.GetStartWarsPeople();
</script>

<style>
    strong {
        border: var(--theme-color) solid 2px;
        border-radius: 3px;
    }
</style>

{#await data}
    <p>Loading...</p>
{:then value}
    {#if Condition.hasSomeValue(value)}
        <div on:click={() => RoutingService.goto("/home")}>
            <Card>
                - Back to Chuck Norris Jokes
            </Card>
        </div>

        {#each value.results as data}
            <!--{JSON.stringify(data)}-->
            <Card>
                <label>Name:</label>
                <strong>{data.name}</strong>
                <br>
                <label>Height:</label>
                <strong>{data.height}</strong>
                <br>
                <label>Mass:</label>
                <strong>{data.mass}</strong>
                <br>
                <label>Hair Color:</label>
                <strong style="--theme-color:{data.hair_color}">{data.hair_color}</strong>
                <br>
                <label>Skin Color:</label>
                <strong style="--theme-color:{data.skin_color}">{data.skin_color}</strong>
                <br>
                <label>Eye Color:</label>
                <strong style="--theme-color:{data.eye_color}">{data.eye_color}</strong>
                <br>
                <label>Birth Year:</label>
                <strong>{data.birth_year}</strong>
                <br>
                <label>Gender:</label>
                <strong>{data.gender}</strong>
            </Card>
        {/each}
    {/if}
{/await}