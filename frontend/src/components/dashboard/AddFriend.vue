<script lang="ts">
import { defineComponent } from "vue";

import { addFriend, getUserByUsername } from "../../services/UserService";

import Button from "../Button.vue";

export default defineComponent({
  name: "AddFriend",
  components: {
    Button,
  },
  props: {
    user: {},
    userName: {},
  },
  data() {
    return {
      inputValue: "",
    };
  },
  methods: {
    async friendAdder(username: string) {
      console.log("username", username);
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const friend: any = await getUserByUsername(username);
      const input = {
        userId: "45e33f90-2515-4e43-918f-bac7769465c1",
        friendId: friend.id,
      };
      console.log(input);
      addFriend(input);
    },
  },
});
</script>

<template>
  <div class="add-friend-card">
    <input
      class="input"
      type="text"
      placeholder="friend's username"
      v-model="inputValue"
    />
    <Button
      :btnText="`add friend`"
      :buttonColor="`btn-blue`"
      @click="friendAdder(inputValue)"
    ></Button>
  </div>
</template>

<style scoped lang="scss">
.add-friend-card {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 0.5rem 0.5rem;
  padding: 1rem 1.5rem;
  border-radius: 0.25rem;
  background-color: var(--dark-eerie-black);
  color: var(--dark-light-gray);
  > span {
    font-size: 1rem;
    width: 100%;
    margin: 0.5rem 0;
  }
  > button {
    font-size: 0.8rem;
    margin: 0.5rem 0.5rem;
  }
}
</style>
