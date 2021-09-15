<script lang="ts">
export default {
  name: "Games",
  props: ["games"],
};
</script>

<template>
  <div class="container game-table">
    <h2>Games</h2>
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>game id</th>
          <th>views</th>
          <th>complete</th>
          <th>started</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in games" :key="index">
          <td>{{ item.gameId }}</td>
          <td>{{ item.views }}</td>
          <td>{{ item.isComplete }}</td>
          <td>{{ item.isStarted }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped lang="scss">
.game-table {
  margin: 20px 0 0 0;
  align-self: center;
}
th,
td {
  color: var(--dark-cultured-white);
}
</style>
