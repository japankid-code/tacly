<template>
  <v-dialog width="550">
    <template v-slot:activator="{ on, attrs }">
      <v-btn icon flat v-bind="attrs" v-on="on" :ripple="false">
        <v-icon> mdi-information </v-icon>
      </v-btn>
    </template>
    
    <v-card color="blue lighten-5">
      <v-card-title>
        <span class="headline">About</span>
      </v-card-title>
      <v-card-text>
        <p>Tacly is a multiplayer competitive tic tac toe game. Add your friends and play!!</p>
        <p><a href="https://github.com/japankid-code/tacly">learn more.</a></p>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="green darken-1" text @click="close">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "AboutModal",
  data () {
    return {
      dialog: false,
    }
  },
  methods: {
    close() {
      this.$emit("close");
    },
  },
};
</script>

<style scoped lang="scss">
.v-btn {
  color: var(--dark-eerie-black);
  background: transparent !important;
  border: none !important;
  cursor: pointer !important;
}
</style>
