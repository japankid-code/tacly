<script>
export default {
  name: "Modal",
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
              friends and play tic tac toe!!
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
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #f9f9f9;
  box-shadow: 2px 2px 20px 1px;
  border-radius: 3px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
}

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  position: relative;
  border-bottom: 1px solid #eeeeee;
  color: #171a1c;
  justify-content: space-between;
}

.modal-footer {
  border-top: 1px solid #eeeeee;
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
  top: 0;
  right: 0;
  border: none;
  font-size: 20px;
  padding: 10px;
  cursor: pointer;
  font-weight: bold;
  color: #61c0ff;
  background: transparent;
  cursor: pointer;
}

.btn-blue {
  color: white;
  background: #61c0ff;
  border: 1px solid #61c0ff;
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
