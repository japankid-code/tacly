<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "DisplayBoard",
  props: ["numberOfGames", "numberOfUsers"],
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
    <div class="number">
      games: {{ numberOfGames }}, users: {{ numberOfUsers }}
    </div>
    <div class="btn">
      <button @click="getAllGames()" type="button" class="btn btn-warning">
        Get all Games
      </button>
    </div>
    <div class="button">
      <button @click="getAllUsers()" type="button" class="btn btn-warning">
        Get all Users
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
