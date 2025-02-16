import { useState } from 'react';
import { cn } from '@/lib/utils';
import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';

export function Signup({
  className,
  ...props
}: React.ComponentPropsWithoutRef<'div'>) {
  const [step, setStep] = useState<'signup' | 'confirm'>('signup');

  const handleSignup = (e: React.FormEvent) => {
    e.preventDefault();
    // Add signup logic here, e.g. call an API and send a confirmation code.
    // On success, move to the confirmation step.
    setStep('confirm');
  };

  const handleConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    // Add confirmation logic here, e.g. verify the entered code.
  };

  return (
    <div className={cn('flex flex-col gap-6', className)} {...props}>
      <Card>
        {step === 'signup' && (
          <>
            <CardHeader className="text-center">
              <CardTitle className="text-xl">Create an Account</CardTitle>
              <CardDescription>Sign up with your email address</CardDescription>
            </CardHeader>
            <CardContent>
              <form onSubmit={handleSignup}>
                <div className="grid gap-6">
                  <div className="grid gap-2">
                    <Label htmlFor="email">Email</Label>
                    <Input
                      id="email"
                      type="email"
                      placeholder="m@example.com"
                      required
                    />
                  </div>
                  <div className="grid gap-2">
                    <Label htmlFor="password">Password</Label>
                    <Input id="password" type="password" required />
                  </div>
                  <Button type="submit" className="w-full">
                    Sign Up
                  </Button>
                  <div className="text-center text-sm">
                    Already have an account?{' '}
                    <a href="/login" className="underline underline-offset-4">
                      Login
                    </a>
                  </div>
                </div>
              </form>
            </CardContent>
          </>
        )}
        {step === 'confirm' && (
          <>
            <CardHeader className="text-center">
              <CardTitle className="text-xl">Confirm Your Email</CardTitle>
              <CardDescription>
                Enter the confirmation code sent to your email.
              </CardDescription>
            </CardHeader>
            <CardContent>
              <form onSubmit={handleConfirm}>
                <div className="grid gap-6">
                  <div className="grid gap-2">
                    <Label htmlFor="confirmation-code">Confirmation Code</Label>
                    <Input
                      id="confirmation-code"
                      type="text"
                      placeholder="Enter your code"
                      required
                    />
                  </div>
                  <Button type="submit" className="w-full">
                    Verify Code
                  </Button>
                </div>
              </form>
            </CardContent>
          </>
        )}
      </Card>
      <div className="text-balance text-center text-xs text-muted-foreground [&_a]:underline [&_a]:underline-offset-4 [&_a]:hover:text-primary">
        By clicking continue, you agree to our <a href="#">Terms of Service</a>{' '}
        and <a href="#">Privacy Policy</a>.
      </div>
    </div>
  );
}
