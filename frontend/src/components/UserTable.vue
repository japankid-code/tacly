<script lang="ts">
export default {
  name: "Users",
  props: ["users"],
};
</script>

<template>
  <div class="container user-table">
    <h2>Users</h2>
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>user id</th>
          <th>username</th>
          <th>email</th>
          <th>password</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in users" :key="index">
          <td>{{ item.id }}</td>
          <td>{{ item.userName }}</td>
          <td>{{ item.email }}</td>
          <td>not telling</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped lang="scss">
.user-table {
  margin: 20px 0 0 0;
  align-self: center;
}
th,
td {
  color: var(--dark-cultured-white);
}
</style>
