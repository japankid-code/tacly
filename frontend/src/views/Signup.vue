<script lang="ts">
import { defineComponent } from "vue";

import UserForm from "../components/UserForm.vue";
import Button from "../components/Button.vue";

export default defineComponent({
  name: "Signup",
  components: {
    UserForm,
    Button,
  },
  props: {},
  data() {
    return {
      text: "sign up",
      username: "",
      email: "",
      password: "",
      confirmPass: "",
    };
  },
  methods: {
    createUser() {
      const payload = {
        username: this.username,
        email: this.email,
        password: this.password,
      };
      console.log(payload);
      this.$emit("createUser", payload);
      this.clearForm();
    },
    clearForm() {
      this.username = "";
      this.email = "";
      this.password = "";
      this.confirmPass = "";
    },
  },
});
</script>

<template>
  <div class="sign-up">
    <router-link to="/"><h1>tacly</h1></router-link>
    <UserForm>
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
          <span>email:</span>
          <input
            class="form-control"
            v-model="email"
            name="email"
            autocomplete="on"
          />
        </div>
      </template>
      <template v-slot:option3>
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
      <template v-slot:option4>
        <div class="form-option">
          <span>confirm pass:</span>
          <input
            class="form-control"
            type="password"
            v-model="confirmPass"
            name="confirmpass"
            autocomplete="on"
          />
        </div>
      </template>
      <template v-slot:button>
        <Button :btn-text="text" @click="createUser()"></Button>
      </template>
    </UserForm>
  </div>
</template>

<style scoped lang="scss">
.sign-up {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
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
  a {
    color: #42b983;
    text-decoration: none;
  }
}
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
</style>
