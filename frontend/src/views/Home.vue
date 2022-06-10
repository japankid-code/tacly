<script lang="ts">
import { defineComponent } from "vue";
import Navbar from "../components/Navbar.vue"; // @ is an alias to /src
import CreateGame from "../components/CreateGame.vue";
import DisplayBoard from "../components/DisplayBoard.vue";
import GameTable from "../components/GameTable.vue";
import UserTable from "../components/UserTable.vue";

import { getAllGames, createGame } from "../services/GameService";
import authService from "../services/AuthService";

export default defineComponent({
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Home",
  components: {
    Navbar,
    CreateGame,
    DisplayBoard,
    GameTable,
    UserTable,
  },
  data() {
    return {
      games: [],
      users: [],
      numberOfGames: 0,
    };
  },
  methods: {
    async getGames() {
      const games = await getAllGames();
      this.games = games;
      this.numberOfGames = this.games.length;
    },
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    async createGame(data: any) {
      await createGame(data);
      this.getGames();
    },
    loggedIn(): boolean {
      const loggedIn = authService.loggedIn();
      return loggedIn;
    },
  },
});
</script>

<template>
  <div class="home">
    <Navbar />
    <template v-if="loggedIn()">
      <CreateGame @createGame="createGame($event)" />
    </template>
    <UserTable />
    <DisplayBoard :numberOfGames="numberOfGames" @getAllGames="getGames()" />
    <GameTable v-show="games.length > 0" :games="games" />
  </div>
</template>

<style lang="scss">
.home {
  display: flex;
  flex-direction: column;
  height: 100%;
  background-color: var(--dark-eerie-black);
}
</style>
