<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "FriendList",
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
  <div>friend list</div>
</template>

<style scoped lang="scss"></style>
