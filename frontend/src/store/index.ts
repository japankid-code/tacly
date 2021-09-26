/* eslint-disable @typescript-eslint/no-explicit-any */
import { createStore } from "vuex";

export interface State {
  activeUsers: any[];
}

export default createStore({
  state: {
    activeUsers: [
      {
        games: [
          {
            gameId: "25a485a9-9661-437b-be53-815e2de1440d",
            views: 0,
            isComplete: false,
            isStarted: false,
          },
          {
            gameId: "8450ef2e-f332-4bbb-913e-5add7c35530f",
            views: 0,
            isComplete: false,
            isStarted: false,
          },
          {
            gameId: "8df2a617-81ba-4841-ad79-739bf6a683da",
            views: 0,
            isComplete: false,
            isStarted: false,
          },
        ],
        friends: [
          {
            games: [],
            friends: [],
            id: "3483f10b-425d-4565-baef-1aee47530212",
            userName: "japankid69",
            normalizedUserName: "JAPANKID69",
            email: "japankid69@email.com",
            normalizedEmail: "JAPANKID69@EMAIL.COM",
            emailConfirmed: false,
            passwordHash:
              "AQAAAAEAACcQAAAAEC3oW0nnsRRlYgPKGNQNhv4C6pohVc0/Y1w2bzl/LNIhJUDmGDwJBFYTUXnaws8Omw==",
            securityStamp: "7AFU6GEZYYZT4NK3LNRT5UDFKJAQA77N",
            concurrencyStamp: "54ec63b3-8292-4c6d-8e2f-e11815d29a8d",
            phoneNumber: null,
            phoneNumberConfirmed: false,
            twoFactorEnabled: false,
            lockoutEnd: null,
            lockoutEnabled: true,
            accessFailedCount: 0,
          },
          {
            games: [],
            friends: [],
            id: "d3d2468d-b3b5-4005-aced-242cc58e7650",
            userName: "japankid690",
            normalizedUserName: "JAPANKID690",
            email: "japankid690@string.com",
            normalizedEmail: "JAPANKID690@STRING.COM",
            emailConfirmed: false,
            passwordHash:
              "AQAAAAEAACcQAAAAEFWLCUdnAXFWxotYCArAB4/ayy236FK8MpVlX+4tCoqgRVMXRezUiIrIwAr618qOGQ==",
            securityStamp: "OKRPZZQGJEAW4SZJ32773S2IJ7IHJKNY",
            concurrencyStamp: "ac70cfdd-9ebd-43fd-9b16-8d340dfba5dd",
            phoneNumber: null,
            phoneNumberConfirmed: false,
            twoFactorEnabled: false,
            lockoutEnd: null,
            lockoutEnabled: true,
            accessFailedCount: 0,
          },
        ],
        id: "45e33f90-2515-4e43-918f-bac7769465c1",
        userName: "japankid",
        normalizedUserName: "JAPANKID",
        email: "japankid@string.com",
        normalizedEmail: "JAPANKID@STRING.COM",
        emailConfirmed: false,
        passwordHash:
          "AQAAAAEAACcQAAAAEA2L/1C0iNVVkIi0KAFNwVvU3u6VFxFw226P9Gr+CLzU54RDS8rXjxpY6bTlCdQleA==",
        securityStamp: "ZERA55SA3DEPXBYZNT3O5U6XL65SO2GV",
        concurrencyStamp: "40ad2d38-19c9-4057-9a3b-e89ed1cd510e",
        phoneNumber: null,
        phoneNumberConfirmed: false,
        twoFactorEnabled: false,
        lockoutEnd: null,
        lockoutEnabled: true,
        accessFailedCount: 0,
      },
      {
        games: [],
        friends: [
          {
            games: [],
            friends: [],
            id: "45e33f90-2515-4e43-918f-bac7769465c1",
            userName: "japankid",
            normalizedUserName: "JAPANKID",
            email: "japankid@string.com",
            normalizedEmail: "JAPANKID@STRING.COM",
            emailConfirmed: false,
            passwordHash:
              "AQAAAAEAACcQAAAAEA2L/1C0iNVVkIi0KAFNwVvU3u6VFxFw226P9Gr+CLzU54RDS8rXjxpY6bTlCdQleA==",
            securityStamp: "ZERA55SA3DEPXBYZNT3O5U6XL65SO2GV",
            concurrencyStamp: "40ad2d38-19c9-4057-9a3b-e89ed1cd510e",
            phoneNumber: null,
            phoneNumberConfirmed: false,
            twoFactorEnabled: false,
            lockoutEnd: null,
            lockoutEnabled: true,
            accessFailedCount: 0,
          },
        ],
        id: "d3d2468d-b3b5-4005-aced-242cc58e7650",
        userName: "japankid690",
        normalizedUserName: "JAPANKID690",
        email: "japankid690@string.com",
        normalizedEmail: "JAPANKID690@STRING.COM",
        emailConfirmed: false,
        passwordHash:
          "AQAAAAEAACcQAAAAEFWLCUdnAXFWxotYCArAB4/ayy236FK8MpVlX+4tCoqgRVMXRezUiIrIwAr618qOGQ==",
        securityStamp: "OKRPZZQGJEAW4SZJ32773S2IJ7IHJKNY",
        concurrencyStamp: "ac70cfdd-9ebd-43fd-9b16-8d340dfba5dd",
        phoneNumber: null,
        phoneNumberConfirmed: false,
        twoFactorEnabled: false,
        lockoutEnd: null,
        lockoutEnabled: true,
        accessFailedCount: 0,
      },
    ],
  },
  mutations: {
    addActiveUser(state, item: any) {
      state.activeUsers.push(item);
      console.log("added active user", item);
    },
    removeActiveUser(state, item: any) {
      state.activeUsers = state.activeUsers.filter((user) => {
        return user.id != item.id;
      });
    },
  },
  actions: {
    async addActiveUser({ commit }, item: any) {
      commit("addActiveUser", item);
    },
  },
});
