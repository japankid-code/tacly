<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "PlayerStats",
  components: {},
  props: {
    user: {},
  },
  data() {
    return {
      text: "log in",
    };
  },
  methods: {
    async logMe(id: string) {
      console.log(id);
    },
  },
});
</script>

<template>
  <div>player stats</div>
</template>

<style scoped lang="scss"></style>
