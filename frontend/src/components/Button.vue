<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Button",
  props: {
    btnText: { type: String, required: true, default: "🍣" },
    buttonColor: { type: String, required: true, default: "btn-blue" },
  },
  data() {
    return {
      btn: "btn",
    };
  },
});
</script>

<template>
  <button
    type="submit"
    :class="buttonColor"
    class="btn"
    @click="(e) => e.preventDefault()"
  >
    {{ btnText }}
  </button>
</template>

<style scoped lang="scss">
.btn {
  color: var(--dark-eerie-black);
  font-weight: bolder;
  font-size: 1.2rem;
  align-self: center;
  border: 1px solid var(--dark-maya-blue);
  border-radius: 2px;
  padding: 0.5rem 1rem;
  margin: 0 0 0 0;
  max-width: min-content;
  white-space: nowrap;
  cursor: pointer;
  &:focus {
    outline: none;
  }
}
.btn-blue {
  background-color: var(--dark-maya-blue);
}
.btn-salmon {
  background-color: var(--dark-light-salmon);
}
.btn-gray {
  background-color: var(--dark-light-gray);
}
</style>
