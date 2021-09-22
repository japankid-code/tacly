<script lang="ts">
import { defineComponent } from "vue";

import UserForm from "../components/UserForm.vue";
import Button from "../components/Button.vue";
import authService from "../services/AuthService";
import { loginUser } from "../services/UserService";

export default defineComponent({
  name: "Login",
  components: {
    UserForm,
    Button,
  },
  props: {},
  data() {
    return {
      text: "log in",
      username: "",
      password: "",
    };
  },
  methods: {
    async loginUser() {
      const payload = {
        username: this.username,
        password: this.password,
      };
      let login = await loginUser(payload);
      authService.login(login.token);
      this.clearForm();
    },
    clearForm() {
      this.username = "";
      this.password = "";
    },
  },
});
</script>

<template>
  <div class="log-in">
    <router-link to="/"><h1>tacly</h1></router-link>
    <UserForm :btn-text="text">
      <template v-slot:option1>
        <div class="form-option">
          <span>username:</span>
          <input
            class="form-control"
            v-model="username"
            name="username"
            autocomplete="on"
          />
        </div>
      </template>
      <template v-slot:option2>
        <div class="form-option">
          <span>password:</span>
          <input
            class="form-control"
            type="password"
            v-model="password"
            name="password"
            autocomplete="on"
          />
        </div>
      </template>
      <template v-slot:button>
        <Button :btn-text="text" @click="loginUser()"></Button>
      </template>
    </UserForm>
  </div>
</template>

<style scoped lang="scss">
.log-in {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: var(--dark-eerie-black);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  h1 {
    margin: 0 0 0 0;
    padding: 1.5rem;
    color: var(--dark-cultured-white);
  }
}
.form-option {
  color: var(--dark-eerie-black);
  width: 16rem;
  padding: 0 0 2rem 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.form-control {
  padding: 0.15rem 0.5rem;
  border: 1px solid #d9d9d9;
  width: 9rem;
  height: 1.5rem;
  border-radius: 0.25rem;
}
</style>
