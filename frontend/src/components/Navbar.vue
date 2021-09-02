<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Navbar",
  methods: {
    open() {
      this.$emit("open");
    },
  },
});
</script>

<template>
  <div class="navbar">
    <router-link to="/"><h1>tacly</h1></router-link>
    <nav id="nav">
      <router-link to="/">Home</router-link> |
      <a type="button" class="about-btn" @click="open">About</a> |
      <router-link to="/login">Log in</router-link> |
      <router-link to="/signup">Sign up</router-link>
      <router-view />
    </nav>
  </div>
</template>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.navbar {
  background-color: var(--dark-maya-blue);
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 10;
  color: var(--dark-eerie-black);
  h1 {
    margin: 0 0 0 0;
    padding: 1.5rem;
    color: var(--dark-eerie-black);
  }
  a {
    color: var(--dark-eerie-black);
    text-decoration: none;
  }
  .about-btn {
    color: var(--dark-eerie-black);
    background: transparent;
    border: none;
    cursor: pointer;
  }
}

#nav {
  padding: 20px;
  color: var(--dark-eerie-black);
  a {
    font-weight: bold;
    color: var(--dark-eerie-black);

    &.router-link-exact-active {
      color: #2d7e59;
    }
  }
}
</style>
