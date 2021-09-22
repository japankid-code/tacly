<script>
import { defineComponent } from "vue";

import UserForm from "../components/UserForm.vue";
import Button from "../components/Button.vue";

export default defineComponent({
  name: "CreateGame",
  components: {
    UserForm,
    Button,
  },
  data() {
    return {
      text: "create game",
      userX: "",
      userO: "",
    };
  },
  methods: {
    createGame() {
      const payload = {
        userX: this.userX,
        userO: this.userO,
      };
      this.$emit("createGame", payload);
      this.clearForm();
    },
    clearForm() {
      this.userX = "";
      this.userO = "";
    },
  },
});
</script>

<template>
  <div class="create-game">
    <div class="">
      <h2>Create Game</h2>
      <UserForm>
        <template v-slot:option1>
          <div class="form-option">
            <span>user X:</span>
            <input
              class="form-control"
              v-model="userX"
              name="userX"
              autocomplete="on"
            />
          </div>
        </template>
        <template v-slot:option2>
          <div class="form-option">
            <span>user O:</span>
            <input
              class="form-control"
              v-model="userO"
              name="userO"
              autocomplete="on"
            />
          </div>
        </template>
        <template v-slot:button>
          <Button :btn-text="text" @click="createGame()"></Button>
        </template>
      </UserForm>
    </div>
  </div>
</template>

<style lang="scss">
.form-option {
  color: var(--dark-eerie-black);
  width: 18rem;
  padding: 0 0 2rem 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.form-control {
  padding: 0 0.5rem;
  border: 1px solid #d9d9d9;
  width: 9rem;
  height: 1.5rem;
  border-radius: 0.25rem;
}
.create-game {
  margin: 20px 0 0 0;
  align-self: center;
  display: flex;
  justify-content: center;
}
</style>
