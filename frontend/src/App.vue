<script lang="ts">
import { defineComponent } from "vue";

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
  --dark-light-gray: #d7d6d5;
  --dark-light-salmon: #ffa978;
}
html {
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

.input {
  width: 11rem;
  height: 1.85rem;
  padding: 0 0.5rem;
  margin: 0 0.35rem;
  border-radius: 0.15rem;
  background-color: var(--dark-cultured-white);
  border: 1px solid var(--dark-cultured-white);
  &:focus {
    outline: none;
  }
}

#app-vue {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--dark-cultured-white);
  background-color: var(--dark-eerie-black);
  width: 100vw;
  height: 100vh;
  max-width: calc(100vw);
  max-height: 100vh;
  margin: 0;
  padding: 0;
}
</style>
