<script lang="ts">
import { defineComponent } from "vue";
import Button from "../Button.vue";

export default defineComponent({
  name: "CurrentGames",
  components: {
    Button,
  },
  props: {
    user: {},
    games: [],
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
    <h3 class="ui-card-title">current games</h3>
    <div class="game-list">
      <!-- <div v-for="(item, index) in games" :key="index">
        <span>{{ item.opponent }}</span>
        <span><Button></Button></span>
        <span>{{ item.isStarted }}</span>
      </div> -->
      <div class="game-card">
        <span>item.opponent</span>
        <Button :btnText="`play game`" :buttonColor="`btn-blue`"></Button>
        <Button :btnText="`forfeit`" :buttonColor="`btn-salmon`"></Button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.ui-card {
  color: var(--dark-eerie-black);
  background-color: var(--dark-light-gray);
  border-radius: 0.5rem;
  margin: 2rem 2rem;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  .ui-card-title {
    margin: -0.5rem 0 0.5rem 0;
    padding: 0.15rem 0.5rem;
    align-self: center;
    border-bottom: 2px solid var(--dark-eerie-black);
  }
  > div,
  h2 {
    margin: 0.35rem 0;
    display: flex;
    justify-content: space-between;
  }
}
.game-card {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 0.5rem 0.5rem;
  padding: 0.5rem 1rem;
  border-radius: 0.25rem;
  background-color: var(--dark-eerie-black);
  color: var(--dark-light-gray);
  width: 100%;
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
