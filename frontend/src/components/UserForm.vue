<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "UserForm",
  methods: {
    login() {
      console.log("login");
      this.$emit("login");
    },
    signup() {
      console.log("signup");
      this.$emit("signup");
    },
  },
  props: { btnText: { type: String, required: true, default: "🍣" } },
  data() {
    return {};
  },
});
</script>

<template>
  <transition name="card-fade">
    <div
      class="card"
      role="dialog"
      aria-labelledby="modalTitle"
      aria-describedby="modalDescription"
    >
      <form class="form-body" id="modalDescription">
        <slot name="option1"> This is option 1! </slot>
        <slot name="option2"></slot>
        <slot name="option3"></slot>
        <slot name="option4"></slot>
        <slot name="option5"></slot>
        <slot name="button"></slot>
      </form>
    </div>
  </transition>
</template>

<style scoped lang="scss">
.card {
  background: #f9f9f9;
  filter: drop-shadow(0px 0px 7px rgba(255, 252, 240, 0.5));
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  border-radius: 3px;
}

.form-body {
  position: relative;
  padding: 2rem 2rem;
  display: flex;
  flex-direction: column;
}

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
}

.card-fade-enter,
.card-fade-leave-to {
  opacity: 0;
}

.card-fade-enter-active,
.card-fade-leave-active {
  transition: opacity 0.5s ease;
}
</style>
