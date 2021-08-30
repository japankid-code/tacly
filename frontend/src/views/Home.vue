<script lang="ts">
import { defineComponent } from "vue";
import Navbar from "../components/Navbar.vue"; // @ is an alias to /src
import AboutModal from "../components/AboutModal.vue";
import CreateUser from "../components/CreateUser.vue";
import DisplayBoard from "../components/DisplayBoard.vue";
import UserTable from "../components/UserTable.vue";

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
    };
  },
  methods: {
    showModal() {
      this.isModalVisible = true;
    },
    closeModal() {
      this.isModalVisible = false;
    },
  },
});
</script>

<template>
  <div class="home">
    <Navbar @open="showModal" />
    <AboutModal v-show="isModalVisible" @close="closeModal" />
    <CreateUser></CreateUser>
    <DisplayBoard></DisplayBoard>
    <UserTable></UserTable>
  </div>
</template>

<style lang="scss">
.home {
  display: flex;
  flex-direction: column;
  height: 100%;
  background-color: #171a1c;
}
</style>
