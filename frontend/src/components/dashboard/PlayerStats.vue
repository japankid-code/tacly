<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "PlayerStats",
  components: {},
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
    <h3 class="ui-card-title">player stats</h3>
    <div><span>username</span><span>rank</span></div>
    <h2><span>japankid</span><span>#3</span></h2>
    <div><span>games played:</span><span>47</span></div>
    <div><span>games won:</span><span>13</span></div>
    <div><span>games lost:</span><span>2</span></div>
    <div><span>games tied:</span><span>22</span></div>
    <div><span>win percentage:</span><span>2</span></div>
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
  .ui-card-title {
    margin: -0.5rem 0 0.5rem 0;
    padding: 0.15rem 0.5rem;
    align-self: center;
    border-bottom: 2px solid var(--dark-eerie-black);
  }
  > div,
  h2,
  h3 {
    margin: 0.35rem 0;
    display: flex;
    justify-content: space-between;
  }
}
</style>
