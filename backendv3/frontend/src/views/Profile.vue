<script lang="ts">
import { defineComponent } from "vue";

import authService from "../services/AuthService";
import { addFriend, getUserById } from "../services/UserService";

import NavBar from "../components/Navbar.vue";

import AddFriend from "../components/profile/AddFriend.vue";
import ChallengeCard from "../components/profile/ChallengeCard.vue";
import CurrentGames from "../components/profile/CurrentGames.vue";
import FriendList from "../components/profile/FriendList.vue";
import PlayerStats from "../components/profile/PlayerStats.vue";

export default defineComponent({
  name: "Profile",
  components: {
    NavBar,
    AddFriend,
    ChallengeCard,
    CurrentGames,
    FriendList,
    PlayerStats,
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
    async getUserData(id: string) {
      await getUserById(id);
    },
    async addUserFriend(userId: string, friendId: string) {
      const payload = {
        userId,
        friendId,
      };
      let login = await addFriend(payload);
    },
  },
});
</script>

<template>
  <div>
    <NavBar />
    <div class="column">
      <div class="row">
        <ChallengeCard />
      </div>
      <div class="row">
        <CurrentGames />
        <FriendList><AddFriend /></FriendList>
        <PlayerStats />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
