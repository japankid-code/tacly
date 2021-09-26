<script lang="ts">
import { defineComponent } from "vue";

import AddFriend from "./AddFriend.vue";
import Button from "../Button.vue";

export default defineComponent({
  name: "FriendList",
  components: {
    AddFriend,
    Button,
  },
  props: {
    user: {},
    friends: [],
  },
  data() {
    return {
      text: "log in",
    };
  },
  methods: {
    async logMe(id: string) {
      console.log(id);
    },
  },
});
</script>

<template>
  <div class="ui-card">
    <h3 class="ui-card-title">friend list</h3>
    <div class="friend-card">
      <span>friend</span>
      <Button :btnText="`challenge`" :buttonColor="`btn-salmon`"></Button>
      <Button :btnText="`🗑️`" :buttonColor="`btn-gray`"></Button>
    </div>
    <AddFriend></AddFriend>
  </div>
</template>

<style scoped lang="scss">
.ui-card {
  color: var(--dark-eerie-black);
  background-color: var(--dark-light-gray);
  border-radius: 0.5rem;
  margin: 2rem 2rem;
  padding: 1.5rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-items: flex-end;
  min-height: 21rem;
  .ui-card-title {
    margin: -0.5rem 0 0.5rem 0;
    padding: 0.15rem 0.5rem;
    align-self: center;
    border-bottom: 2px solid var(--dark-eerie-black);
  }
  > h2,
  h3 {
    margin: 0.35rem 0;
    display: flex;
    justify-content: space-between;
  }
  .add-friend-card {
    justify-self: end;
  }
}
.friend-card {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 0.5rem 1.5rem;
  padding: 0.5rem 1rem;
  border-radius: 0.25rem;
  background-color: var(--dark-eerie-black);
  color: var(--dark-light-gray);
  width: 100%;
  max-width: 21rem;
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
