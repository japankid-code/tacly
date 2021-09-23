<script lang="ts">
import { defineComponent } from "vue";
import Button from "../Button.vue";

export default defineComponent({
  name: "ChallengeCard",
  components: {
    Button,
  },
  props: {
    user: {},
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
    <h2 class="challenge-header">You have been challenged!!</h2>
    <section class="challenge-card">
      <div>
        <span>user</span>
        <span>rank</span>
      </div>
      <h2>
        <span>datbear</span>
        <span>#5</span>
      </h2>
      <h3>Challenged you!!</h3>
      <div>
        <Button :btnText="`accept`" :buttonColor="`btn-blue`"></Button>
        <Button :btnText="`decline`" :buttonColor="`btn-salmon`"></Button>
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.ui-card {
  color: var(--dark-eerie-black);
  background-color: var(--dark-light-gray);
  border-radius: 0.85rem;
  padding: 2.5rem;
  h2 {
    margin: -0.75rem 0 1rem 0;
  }
}
.challenge-card {
  display: flex;
  flex-direction: column;
  color: var(--dark-eerie-black);
  background-color: var(--dark-alice-blue);
  border-radius: 0.35rem;
  padding: 1.5rem;
  div,
  h2 {
    display: flex;
    justify-content: space-between;
    padding: 0.25rem;
    margin: 0;
  }
  h3 {
    align-self: center;
  }
}
</style>
