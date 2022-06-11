<script lang="ts">
    import Condition from "../../lib/tools/Condition.js";
    import Card from "../../lib/Card.svelte";

    export let people;
</script>

{#if Condition.hasSomeValue(people)}
    {#each people as data}
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
