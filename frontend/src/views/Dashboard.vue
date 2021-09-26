<script lang="ts">
import { defineComponent } from "vue";

// import auth from "../services/AuthService";
import { addFriend, getUserById } from "../services/UserService";

import NavBar from "../components/Navbar.vue";

import AddFriend from "../components/dashboard/AddFriend.vue";
import ChallengeCard from "../components/dashboard/ChallengeCard.vue";
import CurrentGames from "../components/dashboard/CurrentGames.vue";
import FriendList from "../components/dashboard/FriendList.vue";
import PlayerStats from "../components/dashboard/PlayerStats.vue";

export default defineComponent({
  name: "Dashboard",
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
    games: [],
  },
  data() {
    return {
      text: "log in",
      challenges: [],
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
      await addFriend(payload);
    },
  },
});
</script>

<template>
  <div>
    <NavBar />
    <div class="dashboard">
      <div class="challenge-card-row" v-if="challenges.length === 1">
        <ChallengeCard />
      </div>
      <div class="user-actions-row">
        <div class="column-left">
          <PlayerStats />
          <CurrentGames />
        </div>
        <div class="column-right">
          <FriendList><AddFriend /></FriendList>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.dashboard {
  display: grid;
  grid-template-rows: 1fr;
  justify-content: center;
}
.challenge-card-row,
.user-actions-row {
  display: flex;
  margin: 4rem 0 0 0;
}
.user-actions-row {
  display: grid;
  width: auto;
  grid-template-columns: 1fr 1fr;
}
</style>
