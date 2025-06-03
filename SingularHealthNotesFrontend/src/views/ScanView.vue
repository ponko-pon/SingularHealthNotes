<template>
  <v-main>
    <v-container>
      <div v-if="!scan">No scans selected.</div>
      <v-row v-else>
        <v-col cols="8" class="d-flex flex-column align-center justify-start pt-8">
          <v-card-title class="justify-center">{{ scan.name }}</v-card-title>
          <v-card-text> {{ scan.date }}</v-card-text>
          <v-img :src="scan.imageUrl" aspect-ratio="1.25" width="1000" class="mb-6"></v-img>
          <AddNote :scan="scan" @note-added="handleNoteAdded"></AddNote>
        </v-col>
        <v-col class="d-flex flex-column align-center justify-start pt-8">
          <NoteList :notes="scan.notes"></NoteList>
        </v-col>
      </v-row>
    </v-container>
  </v-main>
</template>

<script setup lang="ts">
import type { Scan, Note } from '@/types/Scan'
import NoteList from '@/components/NoteList.vue'
import AddNote from '@/components/AddNote.vue'

const props = defineProps<{
  scan: Scan | null
}>();

const emit = defineEmits(['refresh-scan']);

const handleNoteAdded = () => emit('refresh-scan', props.scan?.id);
</script>
