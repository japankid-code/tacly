<script lang="ts">
import { computed, defineComponent } from "vue";
import { useStore } from "vuex";

export default defineComponent({
  name: "Users",
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  data(): any {
    return {};
  },
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  setup(): any {
    const store = useStore();
    let activeUsers = computed(() => store.state.activeUsers).value;
    // return exposes data to the template
    return { activeUsers };
  },
});
</script>

<template>
  <div class="container user-table">
    <h2>Active Users</h2>
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>username</th>
          <th>email</th>
          <th>friends</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in activeUsers" :key="user.id">
          <td>{{ user.userName }}</td>
          <td>{{ user.email }}</td>
          <td>
            <div v-for="friend in user.friends" :key="friend.id">
              {{ friend.userName }}
            </div>
          </td>
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
