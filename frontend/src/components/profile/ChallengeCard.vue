<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ChallengeCard",
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
  <div>challenge card</div>
</template>

<style scoped lang="scss"></style>
