

<template>
  <div>
    <div class="navbar">
      <router-link to="/"><h1>tacly</h1></router-link>
      <nav id="nav">
        <router-link to="/">Home |</router-link>
        <AboutModal />|
        <router-link v-if="!loggedIn()" to="/login">Log in |</router-link>
        <router-link v-if="!loggedIn()" to="/signup">Sign up</router-link>
        <router-link v-if="loggedIn()" to="/dashboard"
          >Dashboard |</router-link
        >
        <router-link v-if="loggedIn()" to="/" @click="logout()">
          Log out
        </router-link>
      </nav>
    </div>
  </div>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import authService from "../services/AuthService";

import AboutModal from "../components/AboutModal.vue";

export default defineComponent({
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Navbar",
  components: {
    AboutModal,
  },
  data() {
    return {

    }
  },
  methods: {
    open() {
      this.$emit("open");
    },
    loggedIn(): boolean {
      const loggedIn = authService.loggedIn();
      return loggedIn;
    },
    logout() {
      authService.logout();
    },
  },
});
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.navbar {
  background-color: var(--dark-maya-blue);
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 10;
  color: var(--dark-eerie-black);
  max-width: 100vw;
  h1 {
    margin: 0 0 0 0;
    padding: 1.5rem;
    color: var(--dark-eerie-black);
  }
  a {
    color: var(--dark-eerie-black);
    text-decoration: none;
  }
  // .about-btn {
  //   color: var(--dark-eerie-black);
  //   background: transparent;
  //   border: none;
  //   cursor: pointer;
  // }
  // #nav {
  //   padding: 0 1rem 0 0;
  //   color: var(--dark-eerie-black);
  //   a {
  //     padding: 0.25rem;
  //     font-weight: bold;
  //     color: var(--dark-eerie-black);
  //   }
  // }
}
</style>
