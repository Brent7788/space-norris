<script lang="ts">
    import Condition from "../../lib/tools/Condition.js";
    import StarWarsDetails from "../../lib/StarWarsDetails.svelte";

    export let people;
</script>

{#if Condition.hasSomeValue(people)}
    {#each people as data}
        <StarWarsDetails people={data}></StarWarsDetails>
    {/each}
{/if}
