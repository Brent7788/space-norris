<script lang="ts">
    import Condition from "../../lib/tools/Condition.js";
    import NorrisJokeDetails from "../../lib/NorrisJokeDetails.svelte";

    export let jokes;
</script>

{#if Condition.hasSomeValue(jokes)}
    {#each jokes as joke}
        <NorrisJokeDetails {joke}></NorrisJokeDetails>
    {/each}
{/if}