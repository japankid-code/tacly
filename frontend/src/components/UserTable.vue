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
          <th>User Id</th>
          <th>Firstname</th>
          <th>Lastname</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in users" :key="index">
          <td>{{ index + 1 }}</td>
          <td>{{ item.firstName }}</td>
          <td>{{ item.lastName }}</td>
          <td>{{ item.email }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style lang="scss">
.user-table {
  margin: 20px 0 0 0;
  align-self: center;
}
</style>
