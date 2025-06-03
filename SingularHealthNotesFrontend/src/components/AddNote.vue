<template>
  <v-card width="100%">
    <v-card-title>Add a Note</v-card-title>
    <v-card-text>
      <v-form ref="form" v-model="validNote" @submit.prevent="handleSubmit">
        <v-text-field label="Title" v-model="newNote.title" :rules="[rules.required]" required />
        <v-textarea
          class="mt-2"
          v-model="newNote.content"
          label="Content"
          :rules="[rules.required]"
          rows="3"
          required
        />
        <v-btn class="mt-2" type="submit" :disabled="!validNote" color="primary">Add Note</v-btn>
      </v-form>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { Scan, Note } from '@/types/Scan'
import { scanService } from '@/services/apiService'

const validNote = ref(false);
const form = ref();

const emit = defineEmits(['note-added']);

const rules = {
  required: (value: string) => !!value || 'This field is required',
};

const props = defineProps<{
  scan: Scan
}>();

const newNote = ref<Note>({
  title: '',
  content: '',
});

const handleSubmit = async () => {
  if (!form.value) return;

  if (!validNote) return;

  //Add new notes onto existing scan
  const updatedScan: Scan = {
    ...props.scan,
    notes: [...(props.scan.notes ?? []), { ...newNote.value }],
  };

  try {
    await scanService.updateScan(updatedScan.id, updatedScan)

    //Reset the form
    newNote.value = { title: '', content: '' };
    form.value.reset();

    emit('note-added');

  } catch (error) {
    console.error('Failed to update scan with note:', error);
  }
};
</script>
