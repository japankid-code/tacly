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
body {
  margin: 0;
}
#app-vue {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  width: 100vw;
  height: 100vh;
  margin: 0;
  padding: 0;
}
</style>
