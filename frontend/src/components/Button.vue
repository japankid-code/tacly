<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Button",
  props: { btnText: { type: String, required: true, default: "🍣" } },
  data() {
    return {};
  },
});
</script>

<template>
  <button type="submit" class="btn-blue" @click="(e) => e.preventDefault()">
    {{ btnText }}
  </button>
</template>

<style scoped lang="scss">
.btn-blue {
  color: #171a1c;
  font-weight: bolder;
  font-size: 1.2rem;
  align-self: center;
  background: #61c0ff;
  border: 1px solid #61c0ff;
  border-radius: 2px;
  padding: 0.5rem 1rem;
  margin: 0 0 0 0;
  max-width: min-content;
  white-space: nowrap;
  cursor: pointer;
}
</style>
