The Simulator allows to study dynamical systems
like growth models, billiard, coupled pendulums,
iterations in the complex plane, celestial mechanics.

The mathematics behind is documented in German
and English. See "Dynamische Systeme" or "Dynamic Systems"
in the folder Simulator/Documentation. 
There is also the technical documentation
and the user manual in G/E.

If you just need the MSI installer for the Simulator
see the Release Tab on the right side. Because the
setup-file is not downloaded often, a security
warning will show up. You can ignore it, the
setup-file is signed with the MS signtool.

## Technical notes

The Simulator is written in VB.NET (Windows Forms)
and runs on .NET 10.

### Numerics: Double

All calculations use the type Double (until 2026 the
models computed in Decimal). Double is much faster
(in Dynamics, the Feigenbaum diagram took 13 s instead
of 150 s).
Chaotic orbits (pendulums, attractors, billiard, universe)
differ from the Decimal version after some time,
because the rounding errors grow exponentially.

- Growth models: the start value for a given protocol is
  computed with Math.Sin or Math.Cos, which work in Double
  anyway. Double reproduces the protocols at least as well
  as Decimal did (measured with protocols of 44 digits:
  99.9 % for the logistic growth and the parabola).
- Tent map: its iteration step still computes in Decimal.
  With a = 2, binary Double shifts out one bit per step,
  so every orbit would fall to the fixed point 0 after
  about 53 steps.
- Overflow: Decimal threw an OverflowException, Double goes
  on with infinity or NaN. ClsNumericCheck restores the old
  behaviour: the pendulums stop with a message, the angle
  normalisations throw for NaN, and the input fields do not
  accept "NaN" or "Infinity".

### Corrections found by the port to Dynamics

The Simulator was ported to C# and the web ("Dynamics").
The errors found during the port were corrected here as
well (commit 9cbc769), among others: the 4th Runge-Kutta
stage of the real thread pendulum, the universe Runge-Kutta
step of order 4 (all stars together; some start parameters
of the constellations were adapted), the stadium billiard,
the spiral scan of the Julia sets, the Newton iteration
with a changed c, the linear map of the strange attractors,
the start value for a target value in the growth models
and several syntax checks of the L-systems.

The code is public and feedbacks are welcome to
h.biner@bluewin.ch.
