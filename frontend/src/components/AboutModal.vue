<script>
export default {
  name: "AboutModal",
  methods: {
    close() {
      this.$emit("close");
    },
  },
};
</script>

<template>
  <transition name="modal-fade">
    <div class="modal-backdrop">
      <div class="modal">
        <header class="modal-header">
          <slot name="header">About Tacly</slot>
          <button type="button" class="btn-close" @click="close">x</button>
        </header>
        <section class="modal-body">
          <slot name="body">
            <p>
              Tacly is a multiplayer competitive tic tac toe game. Add your
              friends and play!!
            </p>
            <p>
              <a href="https://github.com/japankid-code/tacly">learn more.</a>
            </p>
          </slot>
        </section>

        <footer class="modal-footer">
          <slot name="footer"> </slot>
          <button type="button" class="btn-blue" @click="close">close</button>
        </footer>
      </div>
    </div>
  </transition>
</template>

<style scoped lang="scss">
.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  z-index: 10;
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: var(--dark-cultured-white);
  color: var(--dark-eerie-black);
  box-shadow: 2px 2px 20px 1px;
  border-radius: 3px;
  display: flex;
  flex-direction: column;
  width: 23rem;
  height: auto;
  max-height: 80vh;
  max-width: 80vw;
}

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  position: relative;
  border-bottom: 1px solid var(--dark-alice-blue);
  color: var(--dark-eerie-black);
  justify-content: space-between;
}

.modal-footer {
  border-top: 1px solid var(--dark-alice-blue);
  flex-direction: column;
  justify-content: flex-end;
}

.modal-body {
  position: relative;
  padding: 20px 25px;
  display: flex;
  max-width: 320px;
  flex-direction: column;
  align-items: center;
  a {
    font-weight: bold;
    text-decoration: none;
    color: #2c3e50;
  }
}

.btn-close {
  position: absolute;
  top: 0.5rem;
  right: 0.65rem;
  border: none;
  font-size: 20px;
  padding: 10px;
  cursor: pointer;
  font-weight: bold;
  color: var(--dark-maya-blue);
  background: transparent;
}

.btn-blue {
  color: white;
  background: var(--dark-maya-blue);
  border: 1px solid var(--dark-maya-blue);
  border-radius: 4px;
  padding: 0.35rem 0.75rem;
  max-width: min-content;
  align-self: center;
  cursor: pointer;
}

.modal-fade-enter,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}
</style>
