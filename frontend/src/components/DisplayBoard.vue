<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "DisplayBoard",
  props: ["numberOfUsers"],
  methods: {
    getAllUsers() {
      this.$emit("getAllUsers");
    },
  },
});
</script>

<template>
  <div class="display-board">
    <h4>Users Created</h4>
    <div class="number">
      {{ numberOfUsers }}
    </div>
    <div class="btn">
      <button @click="getAllUsers()" type="button" class="btn btn-warning">
        Get all Users
      </button>
    </div>
  </div>
</template>

<style lang="scss">
.display-board {
  margin: 20px 0 0 0;
  align-self: center;
}
</style>
