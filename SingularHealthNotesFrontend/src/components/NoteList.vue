<template>
  <v-card-title>Notes</v-card-title>
  <v-card-text v-if="!notes || notes.length === 0"> No notes available.</v-card-text>
  <v-expansion-panels multiple variant="inset" v-else>
    <v-expansion-panel v-for="(note, index) in props.notes" :key="index">
      <v-expansion-panel-title>
        {{ note.title }}
      </v-expansion-panel-title>
      <v-expansion-panel-text>
        {{ note.content }}
      </v-expansion-panel-text>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script setup lang="ts">
import type { Note } from '@/types/Scan'

const props = defineProps<{
  notes: Note[] | null
}>();
</script>
