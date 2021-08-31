<script lang="ts">
import { defineComponent } from "vue";
import Navbar from "../components/Navbar.vue"; // @ is an alias to /src
import AboutModal from "../components/AboutModal.vue";
import CreateUser from "../components/CreateUser.vue";
import DisplayBoard from "../components/DisplayBoard.vue";
import UserTable from "../components/UserTable.vue";

import { getAllUsers, createUser } from "../services/UserService";

export default defineComponent({
  name: "Home",
  components: {
    Navbar,
    AboutModal,
    CreateUser,
    DisplayBoard,
    UserTable,
  },
  data() {
    return {
      isModalVisible: false,
      users: [],
      numberOfUsers: 0,
    };
  },
  methods: {
    showModal() {
      this.isModalVisible = true;
    },
    closeModal() {
      this.isModalVisible = false;
    },
    async getUsers() {
      const users = await getAllUsers();
      this.users = users;
      this.numberOfUsers = this.users.length;
    },
    userCreate(data: any) {
      createUser(data);
      this.getUsers();
    },
  },
});
</script>

<template>
  <div class="home">
    <Navbar @open="showModal" />
    <AboutModal v-show="isModalVisible" @close="closeModal" />
    <CreateUser @createUser="userCreate($event)" />
    <DisplayBoard :numberOfUsers="numberOfUsers" @getAllUsers="getUsers()" />
    <UserTable v-if="users.length > 0" />
  </div>
</template>

<style lang="scss">
.home {
  display: flex;
  flex-direction: column;
  height: 100%;
  background-color: var(--dark-eerie-black);
}
</style>
