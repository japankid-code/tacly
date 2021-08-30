<script>
import { defineComponent } from "vue";

import UserForm from "../components/UserForm.vue";
import Button from "../components/Button.vue";

export default defineComponent({
  name: "CreateUser",
  components: {
    UserForm,
    Button,
  },
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
  <div class="container create-user">
    <div class="row">
      <div class="col-md-7 mrgnbtm">
        <h2>Create User</h2>
        <UserForm>
          <template v-slot:option1>
            <div class="form-option">
              <span>username:</span>
              <input class="form-control" v-model="username" name="username" />
            </div>
          </template>
          <template v-slot:option2>
            <div class="form-option">
              <span>email:</span>
              <input class="form-control" v-model="email" name="email" />
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
              />
            </div>
          </template>
          <template v-slot:button>
            <Button :btn-text="text" @click="createUser()"></Button>
          </template>
        </UserForm>
      </div>
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
.create-user {
  margin: 20px 0 0 0;
  align-self: center;
}
</style>
