<template>
  <div class="navbar">
    <router-link to="/"><h1>tacly</h1></router-link>
    <nav id="nav">
      <router-link to="/">Home</router-link> |
      <a type="button" class="about-btn" @click="open">About</a> |
      <router-link to="/login">Login</router-link> |
      <router-link to="/signup">Signup</router-link>
      <router-view />
    </nav>
  </div>
</template>

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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.navbar {
  background-color: #61c0ff;
  display: flex;
  justify-content: space-between;
  align-items: center;
  h1 {
    margin: 0 0 0 0;
    padding: 1.5rem;
    color: #2c3e50;
  }
  a {
    color: #42b983;
    text-decoration: none;
  }
  .about-btn {
    color: #2c3e50;
    background: transparent;
    border: none;
    cursor: pointer;
  }
}

#nav {
  padding: 20px;
  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #2d7e59;
    }
  }
}
</style>
