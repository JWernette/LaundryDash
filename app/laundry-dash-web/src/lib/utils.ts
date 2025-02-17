import { clsx, type ClassValue } from "clsx"
import { twMerge } from "tailwind-merge"

// for shadcn library
export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs))
}
