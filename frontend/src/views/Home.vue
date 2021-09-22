<script lang="ts">
import { defineComponent } from "vue";
import Navbar from "../components/Navbar.vue"; // @ is an alias to /src
import CreateGame from "../components/CreateGame.vue";
import DisplayBoard from "../components/DisplayBoard.vue";
import GameTable from "../components/GameTable.vue";
import UserTable from "../components/UserTable.vue";

import { getAllGames, createGame } from "../services/GameService";
import { getAllUsers } from "../services/UserService";
import authService from "../services/AuthService";

export default defineComponent({
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
      numberOfUsers: 0,
      numberOfGames: 0,
    };
  },
  methods: {
    async getUsers() {
      const users = await getAllUsers();
      console.log(users);
      this.users = users;
      this.numberOfUsers = this.users.length;
    },
    async getGames() {
      const games = await getAllGames();
      this.games = games;
      this.numberOfGames = this.games.length;
    },
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
    <template v-if="this.loggedIn()">
      <CreateGame @createGame="createGame($event)" />
    </template>
    <DisplayBoard
      :numberOfUsers="numberOfUsers"
      :numberOfGames="numberOfGames"
      @getAllGames="getGames()"
      @getAllUsers="getUsers()"
    />
    <UserTable v-show="users.length > 0" :users="users" />
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
