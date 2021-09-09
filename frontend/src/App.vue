<script lang="ts">
import { defineComponent } from "vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

export default defineComponent({
  name: "App",
  components: {},
  props: {},
  data() {
    return {};
  },
});
</script>

<template>
  <div id="app-vue">
    <router-view />
  </div>
</template>

<style lang="scss">
* {
  --dark-eerie-black: #171a1c;
  --dark-maya-blue: #61c0ff;
  --dark-alice-blue: #dcf2ff;
  --dark-cultured-white: #f9f9f9;
  --dark-light-salmon: #ffa978;
}
html {
  width: 100vw;
  height: 100vh;
  margin: 0;
  padding: 0;
  background-color: var(--dark-eerie-black);
}

body {
  margin: 0;
}
a {
  text-decoration: none;
}

#app-vue {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--dark-cultured-white);
  background-color: var(--dark-eerie-black);
  width: 100vw;
  height: 100vh;
  margin: 0;
  padding: 0;
}
</style>
