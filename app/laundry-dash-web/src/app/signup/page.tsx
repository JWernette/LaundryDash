'use client';

import { useSearchParams } from 'next/navigation';
import { useEffect, useState } from 'react';
import { GalleryVerticalEnd } from 'lucide-react';

import { Signup } from '@/components/signup-form';
import { AccountSelection } from '@/components/account-selection';

export default function SignupPage() {
  const searchParams = useSearchParams();
  const accountTypeFromQuery = searchParams.get('accountType');
  const [selectedType, setSelectedType] = useState<string | null>(null);

  useEffect(() => {
    if (accountTypeFromQuery) {
      setSelectedType(accountTypeFromQuery);
    }
  }, [accountTypeFromQuery]);

  return (
    <div className="flex min-h-svh flex-col items-center justify-center gap-6 bg-muted p-6 md:p-10">
      <div className="flex w-full max-w-sm flex-col gap-6">
        <a href="#" className="flex items-center gap-2 self-center font-medium">
          <div className="flex h-6 w-6 items-center justify-center rounded-md bg-primary text-primary-foreground">
            <GalleryVerticalEnd className="size-4" />
          </div>
          LaundryDasher
        </a>
        {!selectedType ? (
          // Renders the account selection if no type is chosen yet.
          <AccountSelection />
        ) : (
          // Renders the signup form and passes the selected account type.
          <Signup accountType={selectedType} />
        )}
      </div>
    </div>
  );
}
