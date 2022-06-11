<script lang="ts">
    import Condition from "../../lib/tools/Condition.js";
    import Card from "../../lib/Card.svelte";

    export let jokes;
</script>

{#if Condition.hasSomeValue(jokes)}
    {#each jokes as joke}
        <Card>
            <label>Category:</label>
            <strong>{joke.categories[0]}</strong>
            <br>
            <label>Created At:</label>
            {joke.created_at.split(" ")[0]} <!--TODO Find better way-->
            <br>
            <label>Joke:</label>
            <strong>{joke.value}</strong>
        </Card>
    {/each}
{/if}