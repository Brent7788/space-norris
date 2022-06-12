<script lang="ts">
    import {fly} from "svelte/transition";

    import Condition from "../../lib/tools/Condition.js";
    import StarWarsDetails from "../../lib/StarWarsDetails.svelte";

    export let people;
</script>

{#if Condition.hasSomeValue(people)}
    {#each people as data, index}
        <div in:fly={{ x: 400, duration: 400, delay: 20 * index }}>
            <StarWarsDetails people={data}></StarWarsDetails>
        </div>
    {/each}
{/if}
