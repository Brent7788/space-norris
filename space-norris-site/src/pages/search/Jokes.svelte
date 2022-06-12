<script lang="ts">
    import {fly} from "svelte/transition";

    import Condition from "../../lib/tools/Condition.js";
    import NorrisJokeDetails from "../../lib/NorrisJokeDetails.svelte";

    export let jokes;
</script>

{#if Condition.hasSomeValue(jokes)}
    {#each jokes as joke, index}
        <div in:fly={{ x: 400, duration: 400, delay: 20 * index }}>
            <NorrisJokeDetails {joke}></NorrisJokeDetails>
        </div>
    {/each}
{/if}