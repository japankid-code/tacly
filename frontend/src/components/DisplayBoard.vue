<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "DisplayBoard",
  props: ["numberOfGames"],
  methods: {
    getAllGames() {
      this.$emit("getAllGames");
    },
    getAllUsers() {
      this.$emit("getAllUsers");
    },
  },
});
</script>

<template>
  <div class="display-board">
    <h4>Things Created</h4>
    <div class="number">games: {{ numberOfGames }}</div>
    <div class="btn">
      <button @click="getAllGames()" type="button" class="btn btn-warning">
        Get all Games
      </button>
    </div>
  </div>
</template>

<style scoped lang="scss">
.display-board {
  margin: 20px 0 0 0;
  align-self: center;
}

button {
  align-self: center;
}
</style>
